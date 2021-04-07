using System;
using System.ComponentModel.DataAnnotations;
using TradeTracker.Domain.Interfaces;

namespace TradeTracker.Domain.Common
{
    public class BaseEntity : IAuthorizableEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid AccessKey { get; set; }
    }
}