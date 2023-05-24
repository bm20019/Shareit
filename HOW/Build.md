# COMO COMPILARLO



###### REQUISITOS

- .NET (se recomienda .NET6 o .NET7)
  - [NET latest](https://dotnet.microsoft.com/es-es/download/dotnet)



**Compilación**

1. <u>Clona el proyecto:</u> 

   - ```bash
     git clone https://github.com/bm20019/Shareit.git
     ```

2. <u>Posiciónate en la carpeta clonada y entra en "shareit"</u>

   - ```
     cd Shareit
     cd shareit
     ```

3. <u>Una ves este en el folder "shareit" ejecuta "dotnet" para compilar:</u>

   - ```bash
     dotnet build -f {FrameWork} --runtime={Runtime} --sc --no-incremental
     ```

   Explicación de parámetros:

   1. **-f**: Es el framework de destino, por ejemplo: `net7.0`, `net6.0`, `net5.0`, `netcoreapp3.1`, `net48`, `netstandard2.1` [FrameWorks List](https://learn.microsoft.com/en-us/dotnet/standard/frameworks)

      

   2. **--runtime**: La plataforma de destino, aqui se especifica es Sistema Operativo y su arquitectura, por ejemplo: `win-x64`, `win-x86`, `win-arm64`, `linux-x64`, `linux-musl-x64`, `rhel-x64`, `tizen`. NOTA: Para linux solo esta disponible arquitectura de x64.

      

   3. **--sc**: Self-Container, lo que especifica que el software contendra el entorno NET, ya no seria necesario instalar NET en la maquina de destino.

      

   4. **--no-incremental**: hace una compilacion desde cero.

      - Ejemplo:

        ```
        dotnet build -f net7.0 --runtime=linux-x64 --sc --no-incremental
        ```

        

4. <u>Una vez termine de compilar, busca el ejecutable.</u> Este se debe de encontrar dentro de la carpeta "bin/Debug/{NETversion}/"

   - ```
     cd bin/Debug/{framework}/{runtime}/
     ```

   

5. <u>Ejecuta:</u>

   - ```
     shareit --help
     ```

     