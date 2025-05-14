# Blackbird.io Fireflies.ai

Blackbird is the new automation backbone for the language technology industry. Blackbird provides enterprise-scale automation and orchestration with a simple no-code/low-code platform. Blackbird enables ambitious organizations to identify, vet and automate as many processes as possible. Not just localization workflows, but any business and IT process. This repository represents an application that is deployable on Blackbird and usable inside the workflow editor.

## Introduction

<!-- begin docs -->

The Fireflies is a powerful interface designed to provide you with efficient and flexible access to your data. This API allows you to retrieve exactly the data you need in a structured format


## Before setting up

- Log in to your account at [app.fireflies.ai](https://app.fireflies.ai/)
- Navigate to the [Integrations](https://app.fireflies.ai/integrations) section
- Click on [Fireflies API](https://app.fireflies.ai/integrations/custom/fireflies)
- Copy and store your API key securely

## Connecting

1. Navigate to apps and search for Fireflies.
2. Click _Add Connection_.
3. Name your connection for future reference e.g. 'My Fireflies'.
4. Fill in the 'API token' obtained earlier.
5. Click _Connect_

## Actions

### Transcription

- **Get Transcription** Gets transcription and returns general info and JSON file with sentences

### Events

- **On transcription completed** triggers when transcription is completed

## Examples

![example](image/README/fireflies-example.png)

The workflow depicted in the image above is triggered when a meeting transcription is completed. It automatically retrieves the meeting dialog, summarizes it using an LLM, translates the summary into Spanish, converts it into audio, and distributes the Spanish summary through Microsoft Teams and the audio file through Slack.

## Feedback

Do you want to use this app or do you have feedback on our implementation? Reach out to us using the [established channels](https://www.blackbird.io/) or create an issue.

<!-- end docs -->
