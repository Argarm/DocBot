# 🚧👷‍♂️WIP UnderConstrucction🚧



> Parte de este documento a sido autogenerado por el bot 🤖.

# Proyecto Bot de AI para Preguntas sobre Documentos PDF

Este proyecto consiste en un bot de inteligencia artificial desarrollado en C# que permite a los usuarios cargar documentos en formato PDF y hacer preguntas sobre el contenido de estos documentos. Utilizando Azure OpenAI, Azure Search y Blob Storage, el bot puede extraer información relevante y proporcionar respuestas contextuales.

## Características
- Carga y almacenamiento de documentos PDF en Azure Blob Storage.
- Extracción del texto de los documentos PDF para su indexación.
- Búsqueda eficiente de información utilizando Azure Search.
- Interacción con Azure OpenAI para generar respuestas a las preguntas del usuario basadas en el contexto del documento.
## Requisitos
- **IDE de preferencia Rider o VisualStudio**
- **.NET 8.0 o superior**
- **Cuenta de Azure** (con acceso a Azure OpenAI, Azure Search y Blob Storage)

## Instalación.

**Clonar el repositorio**
```bash\n
git clone https://github.com/Argarm/DocBot.git
cd nombre_del_repositorio
```

**Configurar las credenciales de Azure**
Rellena las siguientes variables:

* AzureOpenAI:Endpoint : Endpoint del servicio que se va a usar
* AzureOpenAI:Key : ApiKey del servicio
## Uso. 

**Hacer preguntas**:

Una vez que el documento está disponible en el sistema, los usuarios pueden hacer preguntas sobre el contenido, y el bot responderá utilizando la API de Azure OpenAI.

## Ejemplo de Código
