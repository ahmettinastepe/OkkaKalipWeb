using OkkaKalipWeb.UI.Enums;
using OkkaKalipWeb.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OkkaKalipWeb.UI.Services
{
    public static class ToastrService
    {
        private static readonly List<(DateTime Date, string UserId, Toastr Toastr)> _toastrs =
            new List<(DateTime Date, string UserId, Toastr Toastr)>();

        public static string UserName { get; set; }

        private static string GetUserId()
        {
            return UserName;
        }
        public static void AddToUserQueue(Toastr toastr)
        {
            _toastrs.Add((Date: DateTime.Now, UserId: GetUserId(), Toastr: toastr));
        }

        public static void AddToUserQueue(string message, string title, ToastrType toastrType)
        {
            AddToUserQueue(new Toastr(message, title, toastrType));
        }

        public static bool HasUserQueue()
        {
            return _toastrs.Any(x => x.UserId == GetUserId());
        }

        public static void RemoveUserQueue()
        {
            _toastrs.RemoveAll(x => x.UserId == GetUserId());
        }

        public static void ClearAll()
        {
            _toastrs.Clear();
        }

        public static List<(DateTime Date, string UserId, Toastr Toastr)> ReadUserQueue()
        {
            return _toastrs.Where(x => x.UserId == GetUserId()).OrderBy(x => x.Date).ToList();
        }

        public static List<(DateTime Date, string UserId, Toastr Toastr)> ReadAndRemoveUserQueue()
        {
            var list = ReadUserQueue();
            RemoveUserQueue();

            return list;
        }
    }
}