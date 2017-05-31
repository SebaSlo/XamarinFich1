using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFich1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VEjercicios : ContentPage
    {
        public VEjercicios()
        {
            InitializeComponent();
            //BindingContext = new VEjerciciosViewModel();
        }

    //    void handle_itemtapped(object sender, itemtappedeventargs e)
    //        => ((listview)sender).selecteditem = null;

    //    async void handle_itemselected(object sender, selecteditemchangedeventargs e)
    //    {
    //        if (e.selecteditem == null)
    //            return;

    //        await displayalert("selected", e.selecteditem.tostring(), "ok");

    //        //deselect item
    //        ((listview)sender).selecteditem = null;
    //    }
    //}



    //class vejerciciosviewmodel : inotifypropertychanged
    //{
    //    public observablecollection<item> items { get; }
    //    public observablecollection<grouping<string, item>> itemsgrouped { get; }

    //    public vejerciciosviewmodel()
    //    {
    //        items = new observablecollection<item>(new[]
    //        {
    //            new item { text = "baboon", detail = "africa & asia" },
    //            new item { text = "capuchin monkey", detail = "central & south america" },
    //            new item { text = "blue monkey", detail = "central & east africa" },
    //            new item { text = "squirrel monkey", detail = "central & south america" },
    //            new item { text = "golden lion tamarin", detail= "brazil" },
    //            new item { text = "howler monkey", detail = "south america" },
    //            new item { text = "japanese macaque", detail = "japan" },
    //        });

    //        var sorted = from item in items
    //                     orderby item.text
    //                     group item by item.text[0].tostring() into itemgroup
    //                     select new grouping<string, item>(itemgroup.key, itemgroup);

    //        itemsgrouped = new observablecollection<grouping<string, item>>(sorted);

    //        refreshdatacommand = new command(
    //            async () => await refreshdata());
    //    }

    //    public icommand refreshdatacommand { get; }

    //    async task refreshdata()
    //    {
    //        isbusy = true;
    //        //load data here
    //        await task.delay(2000);

    //        isbusy = false;
    //    }

    //    bool busy;
    //    public bool isbusy
    //    {
    //        get { return busy; }
    //        set
    //        {
    //            busy = value;
    //            onpropertychanged();
    //            ((command)refreshdatacommand).changecanexecute();
    //        }
    //    }


    //    public event propertychangedeventhandler propertychanged;
    //    void onpropertychanged([callermembername]string propertyname = "") =>
    //        propertychanged?.invoke(this, new propertychangedeventargs(propertyname));

    //    public class item
    //    {
    //        public string text { get; set; }
    //        public string detail { get; set; }

    //        public override string tostring() => text;
    //    }

    //    public class grouping<k, t> : observablecollection<t>
    //    {
    //        public k key { get; private set; }

    //        public grouping(k key, ienumerable<t> items)
    //        {
    //            key = key;
    //            foreach (var item in items)
    //                this.items.add(item);
    //        }
    //    }
    }
}