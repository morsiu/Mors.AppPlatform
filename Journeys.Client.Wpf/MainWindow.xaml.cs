﻿using Journeys.Client.Wpf.Infrastructure;
using Journeys.Command;
using Journeys.Query;

namespace Journeys.Client.Wpf
{
    public partial class MainWindow
    {
        internal MainWindow(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher, EventBus eventBus)
        {
            InitializeComponent();
            AddJourney.DataContext = new AddJourneyWithLiftViewModel(commandDispatcher, eventBus);
            var journeysViewModel = new JourneysWithLiftsViewModel(eventBus, queryDispatcher);
            Journeys.DataContext = journeysViewModel;
            journeysViewModel.Reload();
        }        
    }
}
