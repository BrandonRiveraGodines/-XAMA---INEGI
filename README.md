# -XAMA---INEGI
Proyecto para residencias INEGI

Para poder echar a andar el proyecto debes "CLONAR" el proyecto, y descargarlo en alguna
ubicación de tu computadora, debes tener instalado los siguientes componentes.
  # Servidor Apache (testeado en versión 2.4.33)
  # MySQL (testeado en versión 5.7.21)
  # PHP (testeado en versión 7.2.4)

Debes colocar la carpeta /laboratorio/ en la carpeta publica de tu servidor, referente al
servidor recomiendo instalar:
  # WAMPSERVER (testeado en versión 3.1.3 64bit)

Dentro de la carpeta laboratorio existe un archivo SQL llamado "laboratorio.sql", existe
archivo deberas importarlo en tu "phpmyadmin" posterior a haber creado la base de datos
"laboratorio".

Al momento de abrir la solución del proyecto que está en
  # /-XAMA---INEGI/XamarinInegi/XamarinInegi.sln

Deberas abrir los siguientes archivos de CS dentro de Visual Studio.
  # Login.xaml.cs
  # Registro.xaml.cs
  # FuncionesPage.xaml.cs

Y deberas modificar las lineas correspondientes a la URL a la cual se hará la petición en el
método POST.

Deberas modificar los siguientes archivos de PHP dentro de los archivos del servidor.
  # /laboratorio/videos/index.php
  # /laboratorio/products/index.php

Y cambiar la URL correspondientes en la variable $actualpath
