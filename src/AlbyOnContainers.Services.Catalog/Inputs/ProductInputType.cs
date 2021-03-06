﻿using Catalog.Models;
using GraphQL.Types;

namespace Catalog.Inputs
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class ProductInputType : InputObjectGraphType<ProductAggregate>
    {
        public ProductInputType()
        {
            Name = "ProductInput";

            Field(product => product.Id, nullable: true);
            Field(product => product.Name);
            Field(product => product.CategoryId);
            Field<ListGraphType<AttributeDescriptionInputType>>("descriptions");
        }
    }
}