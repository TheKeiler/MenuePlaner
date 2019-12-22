﻿using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using MenuPlanerApp.Adapters;

namespace MenuPlanerApp
{
    [Activity(Label = "ShoppingListActivity")]
    public class ShoppingListActivity : AppCompatActivity
    {
        private int _selectedMenuPlanId;
        private ShoppingListAdapter _shoppingListAdapter;
        private RecyclerView.LayoutManager _shoppingListLayoutManager;
        private RecyclerView _shoppingListRecyclerView;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            _selectedMenuPlanId = Intent.Extras.GetInt("selectedMenuPlanId");
            SetContentView(Resource.Layout
                .menuPlan_shoppingList);
            _shoppingListRecyclerView = FindViewById<RecyclerView>(Resource.Id.shoppingListRecyclerView);

            _shoppingListLayoutManager = new LinearLayoutManager(this);
            _shoppingListRecyclerView.SetLayoutManager(_shoppingListLayoutManager);
            _shoppingListAdapter = new ShoppingListAdapter(_selectedMenuPlanId);
            await _shoppingListAdapter.LoadData();
            _shoppingListRecyclerView.SetAdapter(_shoppingListAdapter);
        }
    }
}