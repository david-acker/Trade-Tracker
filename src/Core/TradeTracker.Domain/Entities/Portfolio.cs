// using System;
// using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
// using TradeTracker.Domain.Common;
// using TradeTracker.Domain.Enums;

// namespace TradeTracker.Domain.Entities
// {
//     public class Portfolio : AuditableEntity
//     {
//         [Key]
//         public Guid PortfolioId { get; set; } = Guid.NewGuid();

//         public Guid AccessKey { get; set; }

//         public Dictionary<string, Position> Positions { get; set; }

//         [NotMapped]
//         public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
//     }
// }