﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace TradieApp.Domain.Enums;

public enum JobStatusEnum
{
    @new,
    accepted,
    declined
}
