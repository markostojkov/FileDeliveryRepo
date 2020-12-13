using Newtonsoft.Json;
using System;
using System.Collections.Generic;

using FileDeliveryService.Common.Error;

namespace FileDeliveryService.Common.ValueObjects
{
    public class PagingValue : BaseValueObject
    {
        const int maxPageCount = 50;

        public int Page { get; private set; }
        public int PageSize { get; private set; }
        public int Skip { get; private set; }
        public int Take { get; private set; }

        /// <summary>
        /// The URL query works with pages starting from 1 (human readable), instead of 0 (zero).
        /// </summary>
        public int HumanReadablePage
        {
            get
            {
                return Page + 1;
            }
        }

        [JsonConstructor]
        private PagingValue(int page, int pageSize, int skip, int take)
        {
            Page = page;
            PageSize = pageSize;
            Skip = skip;
            Take = take;
        }

        public static PagingValue Create(int? page, int? pageSize, int maxPageSize = maxPageCount)
        {
            var errorResponse = new ErrorResponse();
            if (page.HasValue && page.Value <= 0)
            {
                errorResponse.AddError(ErrorCodes.PagingValuePageMustBePositive);
                errorResponse.ThrowIfErrors();
            }

            int pageValue;
            if (page.HasValue)
            {
                pageValue = page.Value - 1;
            }
            else
            {
                pageValue = 0;
            }

            int pageSizeValue = pageSize ?? maxPageCount;
            pageSizeValue = Math.Min(pageSizeValue, maxPageCount);

            int skip = pageValue * pageSizeValue;
            int take = pageSizeValue;

            return new PagingValue(pageValue, pageSizeValue, skip, take);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Page;
            yield return PageSize;
        }
    }
}
