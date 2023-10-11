FROM mcr.microsoft.com/dotnet/sdk # bu talimatlarda kullanacağımız bir image dosyası olacak bu image dosyasında kullanılacak bir image'imiz olacak sdk image'i bunun sayesinde ben docker kısmında docker'da container'larımda ilgili uygulama üzerinde gerekli bir build/publish/restore işlemlerini gerçekleştirebileceğim
WORKDIR /app # docker ortamında bir klasör oluşturup içine gireceğiz. 
COPY . . # Şu anda bulunan dosyalarımızı o anki içinde girdiğimiz klasörün içine kopyalayacağız.
RUN dotnet restore # Ardından restore edeceğiz.
RUN dotnet publish EnvironmentExample.csproj -c Release -o out # Ardından publish edeceğiz. Publish ederken dikkat edin bu uygulamanın .csproj dosyasını publish ediyoruz. ve release olarak bir çıktısını alıyorum.
WORKDIR out # Ardından yeniden bir klasör oluşturuyoruz. Bu klasörün içine giriyoruz.
ENV ASNETCORE_URLS="http://*:1453" # Klasör içinde uygulamayı ayağa kaldırıyorum 1453 portunda 
ENTRYPOINT ["dotnet", "EnvironmentExample.dll"] # ve ENTRYPOINT talimatıyla bu dll'i dotnet'le ayağa kaldırıyorum.