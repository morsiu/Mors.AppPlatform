﻿using System;
using System.ComponentModel;
using Journeys.Client.Wpf.Infrastructure.Extensions;
using System.Globalization;

namespace Journeys.Client.Wpf.Components.Calendar
{
    internal class CalendarDay : INotifyPropertyChanged
    {
        private readonly int _dayOfMonth;
        private object _content;
        private DateTime _date;

        public CalendarDay(int dayOfMonth)
        {
            _dayOfMonth = dayOfMonth;
        }

        public void Clear()
        {
            Content = null;
        }

        public void Change(int year, int month)
        {
            _date = new DateTime(year, month, _dayOfMonth);
        }

        public void Fill(object content)
        {
            Content = content;
        }

        public object Content
        {
            get { return _content; }
            private set
            {
                _content = value;
                PropertyChanged.Raise(this);
            }
        }

        public int DayOfMonth
        {
            get { return _dayOfMonth; }
        }

        public int DayOfWeekIndex
        {
            get 
            {
                var dayOfWeek = CultureInfo.CurrentCulture.Calendar.GetDayOfWeek(_date);
                return dayOfWeek == System.DayOfWeek.Sunday
                    ? 6
                    : (int)dayOfWeek - 1;
            }
        }

        public int WeekOfMonthIndex
        {
            get
            {
                return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(_date, CalendarWeekRule.FirstFourDayWeek, System.DayOfWeek.Monday)
                    - CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(new DateTime(_date.Year, _date.Month, 1), CalendarWeekRule.FirstFourDayWeek, System.DayOfWeek.Monday);
            }
        }

        public DateTime Date
        {
            get { return _date; }
            private set
            {
                _date = value;
                PropertyChanged.Raise(this);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
