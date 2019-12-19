﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Support.V7.Widget;
using Android.Views;
using MenuPlanerApp.Core.Model;
using MenuPlanerApp.Core.Repository;
using MenuPlanerApp.Core.Utility;
using MenuPlanerApp.ViewHolders;

namespace MenuPlanerApp.Adapters
{
    public class RecipeAdapter : RecyclerView.Adapter
    {
        private List<Recipe> _recipes;
        private List<Recipe> _recipesFull;

        public override int ItemCount => _recipes.Count;

        public event EventHandler<int> ItemClick;

        public async Task LoadData()
        {
            var recipesRepositoryWeb = new RecipeRepositoryWeb();
            _recipes = await recipesRepositoryWeb.GetAllRecipes();
            FilterRecipesFromOptions();
            _recipesFull = new List<Recipe>(_recipes);
        }

        private async void FilterRecipesFromOptions()
        {
            var recipeFilter = new RecipeFilter();
            _recipes = await recipeFilter.FilterRecipes(_recipes);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is RecipeViewHolder recipeViewHolder)
                recipeViewHolder.RecipeNameTextView.Text =
                    SetRecipesText(position);
        }

        private string SetRecipesText(int position)
        {
            if (string.IsNullOrEmpty(_recipes[position].Description)) return _recipes[position].Name;
            return $"{_recipes[position].Name}, {_recipes[position].Description}";
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context)
                .Inflate(Resource.Layout.recipe_viewholder, parent, false);

            var recipesViewHolder = new RecipeViewHolder(itemView, OnClick);
            return recipesViewHolder;
        }

        private void OnClick(int position)
        {
            var recipeId = _recipes[position].Id;
            ItemClick?.Invoke(this, recipeId);
        }

        public void Filter(string text)
        {
            _recipes.Clear();
            if (string.IsNullOrEmpty(text))
            {
                _recipes.AddRange(_recipesFull);
            }
            else
            {
                text = text.ToLower();
                foreach (var item in _recipesFull)
                    if (item.Name.ToLower().Contains(text))
                        _recipes.Add(item);
            }

            NotifyDataSetChanged();
        }
    }
}