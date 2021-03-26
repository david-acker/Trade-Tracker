using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TradeTracker.Application.Enums;
using TradeTracker.Application.Features.Positions;
using TradeTracker.Application.Features.Positions.Queries.GetPositions;
using TradeTracker.Application.Features.Transactions;
using TradeTracker.Application.Features.Transactions.Commands;
using TradeTracker.Application.Features.Transactions.Commands.CreateTransaction;
using TradeTracker.Application.Features.Transactions.Commands.CreateTransactionCollection;
using TradeTracker.Application.Features.Transactions.Commands.UpdateTransaction;
using TradeTracker.Application.Features.Transactions.Queries.ExportTransactions;
using TradeTracker.Application.Features.Transactions.Queries.GetTransactions;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateTransactionCommandDto, CreateTransactionCommand>();

            CreateMap<TransactionForCreationDto, TransactionForCreationCommandBase>();

            CreateMap<TransactionForCreationCommandBase, Transaction>();

            CreateMap<CreateTransactionCollectionCommand, IEnumerable<Transaction>>();

            CreateMap<Transaction, CreateTransactionCommand>()
                .ForMember(
                    dest => dest.AccessKey,
                    opt => opt.MapFrom(src => src.AccessKey))
                .ReverseMap();

            CreateMap<UpdateTransactionCommandDto, UpdateTransactionCommand>();

            CreateMap<Transaction, UpdateTransactionCommand>()
                .ReverseMap();

            CreateMap<Transaction, TransactionsForExportDto>()
                .ReverseMap(); 

            CreateMap<Transaction, TransactionForReturnDto>()
                .ReverseMap();

            CreateMap<Transaction, CreateTransactionCollectionCommand>()
                .ReverseMap();

            CreateMap<GetPagedTransactionsResourceParameters, GetTransactionsQuery>()
                .ForMember(
                    dest => dest.OrderBy,
                    opt => opt.MapFrom(src => OrderByParser(src.Order)))
                .ForMember(
                    dest => dest.SortOrder,
                    opt => opt.MapFrom(src => SortOrderParser(src.Order)))
                .ForMember(
                    dest => dest.RangeStart,
                    opt => opt.MapFrom(src => (DateTime.Parse(src.RangeStart))))
                .ForMember(
                    dest => dest.RangeEnd,
                    opt => opt.MapFrom(src => (DateTime.Parse(src.RangeEnd))))
                .ForMember(
                    dest => dest.Selection,
                    opt => opt.MapFrom(src => SelectionParser(src.Selection)))
                .ForMember(
                    dest => dest.SelectionType,
                    opt => opt.MapFrom(src => SelectionTypeParser(src.Selection)));

            CreateMap<GetTransactionsQuery, PagedTransactionsResourceParameters>();

            CreateMap<TransactionForReturnDto, TransactionForReturnWithLinksDto>();

            CreateMap<GetPagedPositionsResourceParameters, GetPositionsQuery>()
                .ForMember(
                    dest => dest.OrderBy,
                    opt => opt.MapFrom(src => OrderByParser(src.Order)))
                .ForMember(
                    dest => dest.SortOrder,
                    opt => opt.MapFrom(src => SortOrderParser(src.Order)))
                .ForMember(
                    dest => dest.Including,
                    opt => opt.MapFrom(src => 
                        (src.Including != null)
                            ? ArraySelectionParser(src.Including)
                            : new List<string>()))
                .ForMember(
                    dest => dest.Excluding,
                    opt => opt.MapFrom(src => 
                        (src.Excluding != null)
                            ? ArraySelectionParser(src.Excluding)
                            : new List<string>()));
                
            CreateMap<GetPositionsQuery, PagedPositionsResourceParameters>();

            CreateMap<Position, PositionForReturnDto>();
        }

        private List<string> ArraySelectionParser(string input)
        {
            char[] boundaryCharacters = { '(', ')' };

            return input.Trim(boundaryCharacters).Split(',').ToList();
        }

        private string OrderByParser(string input)
        {
            return input.Split(' ')[0];
        }

        private SortOrder SortOrderParser(string input)
        {
            var sortOrder = SortOrder.Descending;

            var splitInput = input.Split(' ');

            if (splitInput.Count() == 2)
            {
                var sortOrderString = splitInput[1];

                if (sortOrderString.Equals("asc", StringComparison.OrdinalIgnoreCase))
                {
                    sortOrder = SortOrder.Ascending;
                }

                switch(sortOrderString.ToLower())
                {
                    case "asc":
                        sortOrder = SortOrder.Ascending;
                        break;

                    case "desc":
                        sortOrder = SortOrder.Descending;
                        break;

                    default:
                        sortOrder = SortOrder.NotSpecified;
                        break;
                }
            }
            
            return sortOrder;
        }

        private List<string> SelectionParser(string input)
        {
            var selectionList = new List<string>();

            var symbolString = input.Split(' ')[0];

            if (SelectionTypeParser(symbolString) == SelectionType.NotSpecified)
            {
                var selection = symbolString.Split(',');

                if (!String.IsNullOrWhiteSpace(selection[0]))
                {
                    selectionList.AddRange(selection);
                }
            }    
            
            return selectionList;
        }

        private SelectionType SelectionTypeParser(string input)
        {
            var selectionType = SelectionType.NotSpecified;
        
            var splitInput = input.Split(' ');
            
            if (splitInput.Count() == 2)
            {
                var selectionTypeString = splitInput[1];

                switch (selectionTypeString.ToLower())
                {
                    case "include":
                        selectionType = SelectionType.Include;
                        break;

                    case "exclude":
                        selectionType = SelectionType.Exclude;
                        break;

                    default:
                        break;
                }
            }

            return selectionType;
        }
    }
}