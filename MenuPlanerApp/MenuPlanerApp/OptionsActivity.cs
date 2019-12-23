﻿using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using MenuPlanerApp.Core.Model;
using MenuPlanerApp.Core.Repository;

namespace MenuPlanerApp
{
    [Activity(Label = "@string/app_name")]
    public class OptionsActivity : AppCompatActivity
    {
        //Data
        private CheckBox _celiacCheckBox;
        private UserOptions _currentUserOptions;
        private CheckBox _fructoseCheckBox;
        private CheckBox _histaminCheckBox;

        //Navigation
        private Button _ingredientButton;
        private CheckBox _lactoseCheckBox;
        private Button _menusButton;
        private Button _optionsButton;
        private Button _recipeButton;

        //Operations
        private Button _saveButton;

        //IngredientsDetails
        private UserOptionsRepositoryWeb _userOptionsRepository;
        private const string SavedUpdatedDataMessage = "Änderungen gespeichert";
        private const string OptionsAlreadyOpenedMessage = "Optionen bereits geöffnet";


        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.options);
            InitialReferencingObjects();
            await LoadData();
            SetCurrentOptionsAsNewIfNotExistsInRepository();
            FindViews();
            BindDataFromDataToView();
            LinkEventHandlers();
        }

        private void InitialReferencingObjects()
        {
            _userOptionsRepository = new UserOptionsRepositoryWeb();
            _currentUserOptions = new UserOptions();
        }

        private async Task LoadData()
        {
            _currentUserOptions = await UserOptionsRepositoryWeb.GetOptionById(1);
        }

        private void SetCurrentOptionsAsNewIfNotExistsInRepository()
        {
            if (_currentUserOptions == null) _currentUserOptions = new UserOptions();
        }

        private void FindViews()
        {
            FindViewsNavigation();
            FindViewsIngredient();
            FindViewsOperation();
        }

        private void FindViewsNavigation()
        {
            _optionsButton = FindViewById<Button>(Resource.Id.optionsButton);
            _menusButton = FindViewById<Button>(Resource.Id.menusButton);
            _ingredientButton = FindViewById<Button>(Resource.Id.ingredientsButton);
            _recipeButton = FindViewById<Button>(Resource.Id.recipesButton);
        }

        private void FindViewsIngredient()
        {
            _fructoseCheckBox = FindViewById<CheckBox>(Resource.Id.fructoseCheckBox);
            _histaminCheckBox = FindViewById<CheckBox>(Resource.Id.histaminCheckBox);
            _lactoseCheckBox = FindViewById<CheckBox>(Resource.Id.lactoseCheckBox);
            _celiacCheckBox = FindViewById<CheckBox>(Resource.Id.celiacCheckBox);
        }

        private void FindViewsOperation()
        {
            _saveButton = FindViewById<Button>(Resource.Id.saveButton);
        }

        private void BindDataFromDataToView()
        {
            _fructoseCheckBox.Checked = _currentUserOptions.WantsUserToSeeRecipesWithFructose;
            _histaminCheckBox.Checked = _currentUserOptions.WantsUserToSeeRecipesWithHistamin;
            _lactoseCheckBox.Checked = _currentUserOptions.WantsUserToSeeRecipesWithLactose;
            _celiacCheckBox.Checked = _currentUserOptions.WantsUserToSeeRecipesWithCeliac;
        }

        private void BindDataFromViewToData()
        {
            _currentUserOptions.WantsUserToSeeRecipesWithFructose = _fructoseCheckBox.Checked;
            _currentUserOptions.WantsUserToSeeRecipesWithHistamin = _histaminCheckBox.Checked;
            _currentUserOptions.WantsUserToSeeRecipesWithLactose = _lactoseCheckBox.Checked;
            _currentUserOptions.WantsUserToSeeRecipesWithCeliac = _celiacCheckBox.Checked;
        }

        private void LinkEventHandlers()
        {
            _optionsButton.Click += OptionsButton_Click;
            _menusButton.Click += MenusButton_Click;
            _ingredientButton.Click += IngredientsButton_Click;
            _recipeButton.Click += RecipeButton_Click;
            _saveButton.Click += SaveButton_Click;
        }

        private void OptionsButton_Click(object sender, EventArgs e)
        {
            ShowToastMessage(OptionsAlreadyOpenedMessage);
        }

        private void MenusButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MenuPlanActivity));
            StartActivity(intent);
        }

        private void IngredientsButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(IngredientsActivity));
            StartActivity(intent);
        }


        private void RecipeButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(RecipeActivity));
            StartActivity(intent);
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            BindDataFromViewToData();
            await SaveOrUpdateOptions();
            ShowToastMessage(SavedUpdatedDataMessage);
        }

        private async Task SaveOrUpdateOptions()
        {
            if (_currentUserOptions.Id != 0)
                await UserOptionsRepositoryWeb.UpdateOption(_currentUserOptions);
            else
                await UserOptionsRepositoryWeb.PostOption(_currentUserOptions);
        }

        private void ShowToastMessage(string text)
        {
            var toastMessage = text;
            const ToastLength duration = ToastLength.Long;
            Toast.MakeText(this, toastMessage, duration).Show();
        }
    }
}