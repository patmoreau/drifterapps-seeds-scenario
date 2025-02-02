FROM mcr.microsoft.com/dotnet/sdk:9.0

# Install JetBrains Rider (latest version)
USER root
# RUN curl -s "https://download.jetbrains.com/rider/rider-2024.3.4.tar.gz" | tar -xzf - -C /opt && \
#     ln -s /opt/rider-*/bin/rider.sh /usr/local/bin/rider

# [Optional] Install the .NET MAUI workload if needed
# RUN dotnet workload install maui

# Clean up
RUN apt-get clean && rm -rf /var/lib/apt/lists/* /tmp/* /var/tmp/*

# Switch back to a non-root user (good practice)
USER 1000
