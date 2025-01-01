# Kafka Demo Project

這是一個簡單的 Kafka Demo 專案，展示如何使用 Kafka 作為訊息代理進行生產者 (Producer) 與消費者 (Consumer) 的開發與測試。專案使用 `.NET 8` 作為後端框架，並搭配 Docker 環境進行 Kafka 的容器化部署。

---

## 目錄

-   [專案簡介](#專案簡介)
-   [功能](#功能)
-   [架構](#架構)
-   [前置準備](#前置準備)
-   [如何使用](#如何使用)
    -   [環境建置](#環境建置)
    -   [執行專案](#執行專案)
-   [技術細節](#技術細節)
-   [貢獻](#貢獻)
-   [授權](#授權)

---

## 專案簡介

本專案模擬了一個簡單的生產者與消費者應用場景，例如線上訂單處理系統，其中：

-   **生產者** 負責將訊息推送到 Kafka topic。
-   **消費者** 監聽 Kafka topic，並處理對應訊息。

---

## 功能

-   建立 Kafka topic 並產生訊息。
-   消費 Kafka topic 訊息並模擬處理。
-   使用 Docker Compose 啟動 Kafka Broker。

---

## 架構

專案架構圖如下：

```
Producer (.NET 8 Web API)
         |
         v
    Kafka Broker
         |
         v
Consumer (.NET 8 Console App)
```

---

## 前置準備

1. 確保已安裝以下工具：

    - [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
    - [Docker](https://www.docker.com/) 與 [Docker Compose](https://docs.docker.com/compose/)

2. Clone 此專案：
    ```bash
    git clone https://github.com/<your-github-username>/kafka-demo.git
    cd kafka-demo
    ```

---

## 如何使用

### 環境建置

1. 啟動 Kafka 環境：

    ```bash
    docker-compose up -d
    ```

2. 確認 Kafka Broker 與 Zookeeper 已成功啟動。

### 執行專案

1. 啟動生產者 (Producer)：

    ```bash
    cd Producer
    dotnet run
    ```

2. 啟動消費者 (Consumer)：

    ```bash
    cd Consumer
    dotnet run
    ```

3. 使用工具 (如 Postman 或 curl) 發送測試請求到 Producer API：

    ```bash
    curl -X POST http://localhost:5000/api/messages -H "Content-Type: application/json" -d '{"message": "Hello Kafka!"}'
    ```

4. 查看 Consumer Console，應可看到成功接收到訊息並進行處理。

---

## 技術細節

### Producer

-   使用 `Confluent.Kafka` 套件連接 Kafka。
-   提供 RESTful API 以便用戶端發送訊息到 Kafka topic。

### Consumer

-   使用 `Confluent.Kafka` 套件監聽 Kafka topic。
-   模擬業務邏輯進行訊息處理。

### Docker Compose

-   定義 Kafka Broker 和 Zookeeper 容器。
-   確保 Kafka 預設埠 (9092) 開放以供連線。
