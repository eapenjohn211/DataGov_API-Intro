using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataGov_API_Intro.Models
{
    public class ErrorViewModel
{
    public string RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
}
