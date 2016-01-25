using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PromosiMVC.Helpers
{
    public static class DefualtExtensions
    {
        // pick random from list
        public static T PickRandom<T>(this IEnumerable<T> source)
        {
            return source.PickRandom(1).Single();
        }

        public static IEnumerable<T> PickRandom<T>(this IEnumerable<T> source, int count)
        {
            return source.Shuffle().Take(count);
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            return source.OrderBy(x => Guid.NewGuid());
        }

        ////convert to select list
        //public static IEnumerable<SelectListItem> GetList<TEntity>(this IEnumerable<TEntity> collection, Expression<Func<TEntity, object>> keyExpression,
        //    Expression<Func<TEntity, object>> valueExpression, object selectedValue = null)
        //{
        //    var keyField = keyExpression.PropertyName();
        //    var valueField = valueExpression.PropertyName();

        //    return new SelectList(collection, keyField, valueField, selectedValue).ToList();
        //}
        public static List<SelectListItem> ToSelectList<T>(this List<T> objects, Func<T, string> getKey, Func<T, string> getValue)
        {
            var items = new List<SelectListItem>();
            foreach (var item in objects)
            {
                items.Add(new SelectListItem
                {
                    Text = getKey(item),
                    Value = getValue(item),
                    Selected = false
                });
            }
            return items.OrderBy(x => x.Text).ToList();
        }





        public static List<SelectListItem> tToSelectList<T>(this List<T> Items, Func<T, string> getKey, Func<T, string> getValue, string selectedValue, string noSelection, bool search = false)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            if (search)
            {
                items.Add(new SelectListItem { Selected = true, Value = "-1", Text = string.Format("-- {0} --", noSelection) });
            }

            foreach (var item in Items)
            {
                items.Add(new SelectListItem
                {
                    Text = getKey(item),
                    Value = getValue(item),
                    Selected = selectedValue == getValue(item) ? true : false
                });
            }

            return items
                .OrderBy(l => l.Text)
                .ToList();
        }
    }
}