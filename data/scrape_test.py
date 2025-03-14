from selenium import webdriver
from selenium.webdriver.common.by import By
import time
import openai
import requests
from openai.error import APIConnectionError


# Set up Chrome WebDriver
driver = webdriver.Chrome()

# Navigate to the specific job posting URL
url = "https://jobs.careers.microsoft.com/global/en/search?l=en_us&pg=1&pgSz=20&o=Relevance"
driver.get(url)

# Give time for the page to load
time.sleep(5)

# Extract all text from the body of the page
page_text = driver.find_element(By.TAG_NAME, 'body').text

# Close the browser
driver.quit()

# Print the raw page text (optional)
print(page_text)


# # Set up your OpenAI API key
# openai.api_key = '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'

# zscaler_cert_path = "C:/Users/P12AFE9/AppData/Roaming/Certs/PipCert.crt"

# # Define the prompt for the model
# prompt = f"""
# Extract the key information from the following job listing:

# {page_text}

# Please provide the following details:
# - Job Title
# - Location
# - Job Description
# - Responsibilities
# - Requirements
# """

# try:
#     # Set up OpenAI request with custom certificate verification
#     response = openai.Completion.create(
#         engine="text-davinci-004",  # Replace with the appropriate model
#         prompt=prompt,
#         max_tokens=500,
#         temperature=0.5,
#         verify=zscaler_cert_path  # Inject the Zscaler certificate
#     )
#     print(response.choices[0].text.strip())

# except APIConnectionError as e:
#     print(f"API Connection Error: {str(e)}")