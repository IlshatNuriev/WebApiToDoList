using Microsoft.AspNetCore.Mvc;
using WebApiToDoList.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebApiToDoList.Filters
{
    public interface ISortByNameOrStartDate
    {
        public ActionResult<IEnumerable<ProjectItem>> SortProjectItems(IEnumerable<ProjectItem> items, string sortOrder);
    };
}
