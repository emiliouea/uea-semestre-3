// Crear gestor del catálogo
using CatalogoRevistas;

GestorCatalogo gestor = new GestorCatalogo();

// Crear menú
MenuInterfaz menu = new MenuInterfaz(gestor);

// Mostrar menú
menu.MostrarMenu();