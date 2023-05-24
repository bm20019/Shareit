# ![Not Icon](img/icon.png)Shareit CLI .NET

###### Una interfaz de linea de comandos, sencilla para poder compartir archivos a toda nuestra red local; con esta herramienta se pueden compartir un archivo en especifico o un directorio (no se puede compartir subdirectorio).

------

**Requisitos:**

Arquitectura: x64

SO: Linux, Windows 7, 10, 11

------

**Como usarlo?**

*Imprime la ayuda del software*

```bash
shareit --help
```

------

*Comparte el archivo ejemplo.txt en la red local. Por defecto se utiliza la ip ipv4 del sistema y el puerto 8080*

```bash
shareit --input /home/user/Documents/ejemplo.txt
```

*Comparte el folder "Public". De igual manera se utiliza la ip de la red local y el puerto 8080*

```bash
shareit --folder "/home/user/Public"
```



------

*Especificar puerto: se modifica el puerto por defecto 8080 por el puerto 80.*

```bash
shareit --input /home/user/Documents/ejemplo.txt --port 80
```

<u>Ejemplo de url para acceder al archivo compartido: http://0.0.0.0:80</u>



------

*Especificar puerto: si por algun motivo no shareit no dectecta la ip correcta, podes especificarla manualmente*

```bash
shareit --input /home/user/Documents/ejemplo.txt --ip 192.168.1.3
```

<u>Ejemplo de url para acceder al archivo compartido: http://192.168.1.3:80</u>



------

*Modificar puerto y IP*

```bash
shareit --folder "/home/user/Public" --ip 192.168.1.3 --port 8080
```

<u>Ejemplo de url para acceder al archivo compartido: http://192.168.1.3:8080</u>



###### No hacer esto.

```
shareit --folder "/home/user/Public" --input /home/user/Documents/ejemplo.txt
```

solo se compartira el archivo "ejemplo.txt".

| NOTA: para compartir archivos en tu red LAN, es necesario que el puerto a utilizar este expuesto; si estas en windows puedes utilizar el Firewall de Windows para agregar una nueva regla y exponer el puerto. Por otro lado si utilizas GNU/Linux hay varias opciones como ufw, firewalld, iptables, Shorewall, nftables entre otros. |
| ------------------------------------------------------------ |



## COMO COMPILAR.

[Como Compilar](HOW/Build.md)