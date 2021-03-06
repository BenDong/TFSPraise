﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFSPraise.Entities;

namespace TFSPraise.Models
{
    public class ListViewModel<T>
    {
        public IEnumerable<T> List { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}