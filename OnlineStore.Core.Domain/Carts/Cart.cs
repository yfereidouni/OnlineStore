﻿using OnlineStore.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Core.Domain.Carts
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public virtual void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection
            .Where(p => p.Product.ProductId == product.ProductId)
            .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public virtual void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(l => l.Product.ProductId == product.ProductId);
        }
        public virtual decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Product.Price * e.Quantity);
        }
        public virtual void Clear() => lineCollection.Clear();
        public virtual IEnumerable<CartLine> Lines => lineCollection;
    }

}
