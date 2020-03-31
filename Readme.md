Implementation of the backend API 

This webapi is implemented using -
1) .Net core 3.1
2) Onion Architecture
	The UI communicates to business logic through interfaces. It has four layers:
	a) Domain Entities Layer [BeezyBackend.Data]
	b) Repository Layer 	 [BeezyBackend.Repository]
	c) Service Layer		 [BeezyBackend.Service]
	d) UI/Web Layer     	 [BeezyBackend.Web]
	
3) Entity Framework		: DB first approach				
4) Dependency Inversion Principle

