Fue creada una interfaz IGenericRepository, en donde registramos el servicio IRepository.
se registra el servicio mediante el builder builder.Services.AddScoped<IRepository, IStudentRepository>();
Por último se agrega en businessLogic.