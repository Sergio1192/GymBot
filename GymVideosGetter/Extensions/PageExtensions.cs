using System.Collections.Generic;
using System.Threading.Tasks;

namespace PuppeteerSharp
{
    public static class PageExtensions
    {
        public static async Task<T> GetAttributeFromQuerySelectorAsync<T>(this Page page, string selector, string propertyName, bool wait = true)
        {
            if (wait)
                await page.WaitForSelectorAsync(selector);
            
            var attributeValue = await page.EvaluateExpressionAsync<T>($"document.querySelector('{selector}').getAttribute('{propertyName}')");

            return attributeValue;
        }

        public static async Task<IEnumerable<T>> GetAttributeFromQuerySelectorAllAsync<T>(this Page page, string selector, string propertyName, bool wait = true)
        {
            if (wait)
                await page.WaitForSelectorAsync(selector);

            var attributeValues = await page.EvaluateExpressionAsync<T[]>($"Array.from(document.querySelectorAll('{selector}')).map(element => element.getAttribute('{propertyName}'))");

            return attributeValues;
        }

        public static async Task<ElementHandle[]> WaitAndQuerySelectorAllAsync(this Page page, string selector, WaitForSelectorOptions options = null)
        {
            await page.WaitForSelectorAsync(selector, options);
            var elementsHandle = await page.QuerySelectorAllAsync(selector);

            return elementsHandle;
        }
    }
}
