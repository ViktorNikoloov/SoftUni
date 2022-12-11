namespace CouponOps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CouponOps.Models;
    using Interfaces;

    public class CouponOperations : ICouponOperations
    {
        private Dictionary<string, Coupon> allCoupons = new Dictionary<string, Coupon>();
        private Dictionary<string, Website> allWebsites = new Dictionary<string, Website>();

        public void AddCoupon(Website website, Coupon coupon)
        {
            if (!this.Exist(website))
            {
                throw new ArgumentException();
            }

            allCoupons.Add(coupon.Code, coupon);
            website.Coupons.Add(coupon);
        }

        public bool Exist(Website website)
        => this.allWebsites.ContainsKey(website.Domain);

        public bool Exist(Coupon coupon)
        => this.allCoupons.ContainsKey(coupon.Code);

        public IEnumerable<Coupon> GetCouponsForWebsite(Website website)
        {
            if (!this.allWebsites.ContainsKey(website.Domain))
            {
                throw new ArgumentException();
            }

            return website.Coupons;
        }

        public IEnumerable<Coupon> GetCouponsOrderedByValidityDescAndDiscountPercentageDesc()
        => this.allCoupons
            .Values.OrderByDescending(x => x.Validity)
            .ThenByDescending(x => x.DiscountPercentage);

        public IEnumerable<Website> GetSites()
        => this.allWebsites.Values;

        public IEnumerable<Website> GetWebsitesOrderedByUserCountAndCouponsCountDesc()
        => this.GetSites()
            .OrderBy(x => x.UsersCount)
            .ThenByDescending(x => x.Coupons.Count);

        public void RegisterSite(Website website)
        {
            if (this.Exist(website))
            {
                throw new ArgumentException();
            }

            this.allWebsites.Add(website.Domain, website);
        }

        public Coupon RemoveCoupon(string code)
        {
            if (!this.allCoupons.ContainsKey(code))
            {
                throw new ArgumentException();
            }

            this.allCoupons.Remove(code, out Coupon coupon);

            if (this.GetSites().Any(x => x.Coupons.Contains(coupon)))
            {
                var website = this.GetSites().First(x => x.Coupons.Contains(coupon));
                website.Coupons.Remove(coupon);
            };

            return coupon;
        }

        public Website RemoveWebsite(string domain)
        {
            if (!this.allWebsites.ContainsKey(domain))
            {
                throw new ArgumentException();
            }

            this.allWebsites.Remove(domain, out Website website);
            foreach (var coupon in website.Coupons)
            {
                this.RemoveCoupon(coupon.Code);
            }

            website.Coupons.Clear();

            return website;
        }

        public void UseCoupon(Website website, Coupon coupon)
        {
            if (!this.Exist(website) || !this.Exist(coupon) || !website.Coupons.Contains(coupon))
            {
                throw new ArgumentException();
            }

            website.Coupons.Remove(coupon);
            this.allCoupons.Remove(coupon.Code);
        }
    }
}
