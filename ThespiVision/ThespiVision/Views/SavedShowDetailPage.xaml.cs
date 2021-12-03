﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThespiVision.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SavedShowDetailPage : ContentPage
    {
        Guid showID;
        public SavedShowDetailPage(Guid ID)
        {
            InitializeComponent();
            showID = ID;
        }
    }
}