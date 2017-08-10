using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Sylapse.AutofacPlatformInjection.Droid;
using Android.Support.V7.Widget;
using Android.Support.V7.App;

namespace MainSample.Droid
{
    public class FirstFragment : LifetimeFragment
    {
        [InjectOnCreate]
        private FirstViewModel _firstViewModel;

        [InjectOnCreateView]
        private ItemsAdapter _itemsAdapter;
        
        private RecyclerView _recyclerView;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // ViewModel is ready at this point
            Activity.Title = _firstViewModel.Title;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Must call base when using LifetimeFragment
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.FirstFragment, container, false);
            var toolbar = view.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            (Activity as AppCompatActivity).SetSupportActionBar(toolbar);

            _recyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);
            _recyclerView.SetAdapter(_itemsAdapter);

            // Bind views to view model using preferred technique (e.g. MvvmLight etc)
            _itemsAdapter.SetItems(_firstViewModel.Items);

            return view;
        }
    }

    public class ItemsAdapter : RecyclerView.Adapter
    {
        // Can ask for the LayoutInflater as a dependency. See the LifetimeFragment implementation.
        // Activity, Fragment and LayoutInflater are all registered with autofac.
        private readonly LayoutInflater _inflater;
        private readonly ItemViewHolder.Factory _itemViewHolderFactory;

        private IReadOnlyList<string> _items;

        public ItemsAdapter(
            LayoutInflater inflater,
            ItemViewHolder.Factory itemViewHolderFactory)
        {
            _inflater = inflater;
            _itemViewHolderFactory = itemViewHolderFactory;
        }

        public override int ItemCount => _items.Count();

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = _inflater.Inflate(Resource.Layout.ItemViewHolder, parent, false);
            var itemViewHolder = _itemViewHolderFactory(itemView);
            return itemViewHolder;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var itemViewHolder = (ItemViewHolder)holder;
            itemViewHolder.SetData(_items[position]);
        }

        public void SetItems(IReadOnlyList<string> items)
        {
            _items = items;
            NotifyDataSetChanged();
        }

        internal void Finish()
        {
            // Remove eventhandlers, clean up bitmaps etc
        }
    }

    public class ItemViewHolder : RecyclerView.ViewHolder
    {
        public delegate ItemViewHolder Factory(View view);

        private readonly TextView _textViewTitle;

        public ItemViewHolder(
            View view,
            Activity activity) : base(view)
        {
            _textViewTitle = view.FindViewById<TextView>(Resource.Id.textView);
        }

        public void SetData(string item)
        {
            _textViewTitle.Text = item;
        }

        internal void Finish()
        {
            // Remove eventhandlers, clean up bitmaps etc
        }
    }
}