# redist-tester

C# program to test setting/reading redis values from docker-compose.

## Build and Usage with `docker-compose`

```code
$ docker-compose REDIS_TESTER_APP up --build

PS C:\redis-tester> docker-compose -p REDIS_TESTER up --build
Building redis
[+] Building 0.4s (6/6) FINISHED
 => [internal] load build definition from Dockerfile.redis                                                                                                                                                                       0.0s
 => => transferring dockerfile: 166B                                                                                                                                                                                             0.0s
 => [internal] load .dockerignore                                                                                                                                                                                                0.0s
 => => transferring context: 35B                                                                                                                                                                                                 0.0s
 => [internal] load metadata for docker.io/library/redis:latest                                                                                                                                                                  0.0s
 => [1/2] FROM docker.io/library/redis:latest                                                                                                                                                                                    0.1s
 => [2/2] RUN mkdir -p /usr/local/etc/redis && echo "notify-keyspace-events AKE" > /usr/local/etc/redis/redis.conf                                                                                                               0.2s
 => exporting to image                                                                                                                                                                                                           0.0s
 => => exporting layers                                                                                                                                                                                                          0.0s
 => => writing image sha256:64550d8e82889412e86d298c200decaef0c8e0b6f184314304da84296eb138c5                                                                                                                                     0.0s
 => => naming to docker.io/library/redis:latest                                                                                                                                                                                  0.0s
Building redistest
[+] Building 5.9s (18/18) FINISHED
 => [internal] load build definition from Dockerfile                                                                                                                                                                             0.0s
 => => transferring dockerfile: 567B                                                                                                                                                                                             0.0s
 => [internal] load .dockerignore                                                                                                                                                                                                0.0s
 => => transferring context: 35B                                                                                                                                                                                                 0.0s
 => [internal] load metadata for mcr.microsoft.com/dotnet/sdk:6.0                                                                                                                                                                1.2s
 => [internal] load metadata for mcr.microsoft.com/dotnet/runtime:6.0                                                                                                                                                            1.1s
 => [base 1/2] FROM mcr.microsoft.com/dotnet/runtime:6.0@sha256:7eb42220fab5e8db485d61a7fbdbb97d61f46411a273ca6a5d7c74eef012b1c7                                                                                                 0.0s
 => [build 1/7] FROM mcr.microsoft.com/dotnet/sdk:6.0@sha256:a00768bd38f35800c9e8042abae13c72d694603598167843e042581dd7513ab2                                                                                                    0.0s
 => [internal] load build context                                                                                                                                                                                                0.0s
 => => transferring context: 1.57kB                                                                                                                                                                                              0.0s
 => CACHED [build 2/7] WORKDIR /src                                                                                                                                                                                              0.0s
 => CACHED [build 3/7] COPY [redistester.csproj, redistester/]                                                                                                                                                                   0.0s
 => CACHED [build 4/7] RUN dotnet restore "redistester/redistester.csproj"                                                                                                                                                       0.0s
 => [build 5/7] COPY . .                                                                                                                                                                                                         0.0s
 => [build 6/7] WORKDIR /src/                                                                                                                                                                                                    0.0s
 => [build 7/7] RUN dotnet build "redistester.csproj" -c Release -o /app/build                                                                                                                                                   2.8s
 => [publish 1/1] RUN dotnet publish "redistester.csproj" -c Release -o /app/publish                                                                                                                                             1.6s
 => CACHED [base 2/2] WORKDIR /app                                                                                                                                                                                               0.0s
 => CACHED [final 1/2] WORKDIR /app                                                                                                                                                                                              0.0s
 => [final 2/2] COPY --from=publish /app/publish .                                                                                                                                                                               0.0s
 => exporting to image                                                                                                                                                                                                           0.0s
 => => exporting layers                                                                                                                                                                                                          0.0s
 => => writing image sha256:1e4415252dc76934b5691b2d6f0d0bf3fef9b85b46f78522989cc755431dad89                                                                                                                                     0.0s
 => => naming to docker.io/library/redistester:latest                                                                                                                                                                            0.0s
Recreating redis_tester_redis_2 ... done
Recreating redis_tester_redistest_2 ... done
Attaching to redis_tester_redis_2, redis_tester_redistest_2
redis_2      | 1:C 08 Feb 2022 18:23:12.147 # oO0OoO0OoO0Oo Redis is starting oO0OoO0OoO0Oo
redis_2      | 1:C 08 Feb 2022 18:23:12.147 # Redis version=6.2.6, bits=64, commit=00000000, modified=0, pid=1, just started
redis_2      | 1:C 08 Feb 2022 18:23:12.147 # Configuration loaded
redis_2      | 1:M 08 Feb 2022 18:23:12.147 * monotonic clock: POSIX clock_gettime
redis_2      | 1:M 08 Feb 2022 18:23:12.148 * Running mode=standalone, port=6379.
redis_2      | 1:M 08 Feb 2022 18:23:12.148 # Server initialized
redis_2      | 1:M 08 Feb 2022 18:23:12.149 * Ready to accept connections
redistest_2  | Saving random data in cache
redistest_2  | Reading data from cache
redistest_2  | ITEM=960757948
redistest_2  | ITEM=982908560
redistest_2  | ITEM=1099701324
redistest_2  | ITEM=923772615
redistest_2  | ITEM=1326460638
redistest_2  | ITEM=1468331048
redistest_2  | ITEM=1984767510
redistest_2  | ITEM=1077159158
redistest_2  | ITEM=1505547967
redistest_2  | ITEM=1420562573
redis_tester_redistest_2 exited with code 0
Gracefully stopping... (press Ctrl+C again to force)
```
