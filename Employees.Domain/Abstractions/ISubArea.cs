﻿using Employees.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Domain.Abstractions
{
    public interface ISubArea
    {
        List<SubArea> ListarSubAreas();
    }
}
