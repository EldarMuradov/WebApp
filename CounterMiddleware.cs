using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Services;

namespace WebApplication
{
    public class CounterMiddleware
    {
        private int i = 0;
        private readonly RequestDelegate _next;
        private int _counterID;
        public CounterMiddleware(RequestDelegate next) => _next = next;
        
        public async Task InvokeAsync(HttpContext context, ICounter counter, 
            CounterService counterService) 
        {
            i++;
            await context.Response.WriteAsync($"Request: {i}, ICounter: {counter.Value}, " +
                $"CounnterService: {counterService.Counter.Value}");
            _next?.Invoke(context);
        }

        private void CounterChecker(int counts) 
        {
        
        }
    }

    public class NewRAndomRange
    {
        private static List<NewRAndomRange> allRanges = new List<NewRAndomRange>(1001);
        private static List<NewRAndomRange> allFixedRanges = new List<NewRAndomRange>(1001);
        private static List<NewRAndomRange> allLateRanges = new List<NewRAndomRange>(1001);

        private readonly string _hash = "";
        private void OnEnabled() 
        {
            allRanges.Add(this);
            allFixedRanges.Add(this);
            allLateRanges.Add(this);
            OnConnectedToRoom(_hash);
        }

        private void OnDisable() 
        {
            allFixedRanges.Remove(this);
            allRanges.Remove(this);
            allLateRanges.Remove(this);
        }

        private void OnDestroyed() 
        {
            allFixedRanges.Remove(this);
            allRanges.Remove(this);
            allLateRanges.Remove(this);
        }

        private void OnConnectedToRoom(string hash) 
        {
            System.Random rnd = new System.Random();
            ChangeList(allRanges, rnd.Next(0,1001), new NewRAndomRange());
        }
       
        private static void ChangeList(List<NewRAndomRange> list, 
            int i, NewRAndomRange newRAndomRange) => list[i] = newRAndomRange;
    }
}
