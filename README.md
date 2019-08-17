# SharpSpringApi
C# Fluent API for SharpSpring

## Get Accounts
```
ApiContext ctx = new ApiContext();
var accounts = ctx.Get().Accounts();
```

## Get Leads
```
ApiContext ctx = new ApiContext();
var leads = ctx.Get().Leads();
```

## Get Campaigns
```
ApiContext ctx = new ApiContext();
var campaigns = ctx.Get().Campaigns();
```

## Get Lists and Members
```
ApiContext ctx = new ApiContext();
var lists = ctx.Get().Lists();
foreach(var l in lists) {
  ctx.Get().ListMembers(l.Id);
}
```
