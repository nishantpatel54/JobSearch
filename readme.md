# Job search start up

# Initial Phase - Implementation of Core Components

- Barebones API for Job search
    - Insertion of Jobs single and in bulk
    - Simple CRUD operations

- Scrapper to get jobs from popular sources
- Scrape data until we reach a "saturation" point

# Phase 2 - Embedding + search
- Embedding of the collected test data
- Simple search using Elastic search on embedded data

# Phase 3 - Containerize + Orchestrate
- Containerize the scrapper and job api services
- Orchestrate communication between them in a local K8s cluster
- Integrate the external Data services