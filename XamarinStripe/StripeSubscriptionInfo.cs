/*
 * Copyright 2011 Joe Dluzen
 *
 * Author(s):
 *  Joe Dluzen (jdluzen@gmail.com)
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;
using System.Globalization;
using System.Text;
using System.Web;

namespace Xamarin.Payments.Stripe {
    public class StripeSubscriptionInfo : IUrlEncoderInfo {
        public string Plan { get; set; }

        public string Coupon { get; set; }

        public DateTime? TrialEnd { get; set; }

        public StripeCreditCardInfo Card { get; set; }

        public decimal? ApplicationFeePercentage { get; set; }

        public int? Quantity { get; set; }


        public virtual void UrlEncode (StringBuilder sb)
        {
            sb.AppendFormat ("plan={0}&", HttpUtility.UrlEncode (Plan));
            if (!string.IsNullOrEmpty (Coupon))
                sb.AppendFormat ("coupon={0}&", HttpUtility.UrlEncode (Coupon));
            if (ApplicationFeePercentage != null && ApplicationFeePercentage.HasValue)
                sb.AppendFormat("application_fee_percent={0}&", ApplicationFeePercentage.Value.ToString(CultureInfo.InvariantCulture).ToLowerInvariant());
            if (Quantity != null && Quantity.HasValue)
                sb.AppendFormat("quantity={0}&", Quantity.Value.ToString(CultureInfo.InvariantCulture).ToLowerInvariant());
            if (TrialEnd != null)
                sb.AppendFormat ("trial_end={0}&", TrialEnd.Value.ToUnixEpoch ());
            if (Card != null)
                Card.UrlEncode(sb);
        }
    }
}
