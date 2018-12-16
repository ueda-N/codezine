﻿using System;
using System.Threading.Tasks;

using Sample02.Tabs.MvvmLight.Helpers;
using Sample02.Tabs.MvvmLight.Services;
using Sample02.Tabs.MvvmLight.ViewModels;

using Windows.ApplicationModel.Activation;

namespace Sample02.Tabs.MvvmLight.Activation
{
    internal class DefaultLaunchActivationHandler : ActivationHandler<LaunchActivatedEventArgs>
    {
        private readonly string _navElement;

        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        public DefaultLaunchActivationHandler(Type navElement)
        {
            _navElement = navElement.FullName;
        }

        protected override async Task HandleInternalAsync(LaunchActivatedEventArgs args)
        {
            // When the navigation stack isn't restored, navigate to the first page and configure
            // the new page by passing required information in the navigation parameter
            NavigationService.Navigate(_navElement, args.Arguments);

            // TODO WTS: Remove or change this sample which shows a toast notification when the app is launched.
            // You can use this sample to create toast notifications where needed in your app.
            //Singleton<ToastNotificationsService>.Instance.ShowToastNotificationSample();
            // bw: ↑起動時のトースト通知デモは不要なので削除した

            await Task.CompletedTask;
        }

        protected override bool CanHandleInternal(LaunchActivatedEventArgs args)
        {
            // None of the ActivationHandlers has handled the app activation
            return NavigationService.Frame.Content == null;
        }
    }
}
