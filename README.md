# Danske-homework

#To launch:
  1. Start an Api project in development mode. It should open swagger index with endpoints.

#To test:
  1. "Save" endpoint: input a string with various integers like this "1 2 6 9 4 21 46 7 9" in any order and execute. Response should be 200 with the execution times for sorting algorithms
  2. "Retrieve" endpoint: execute an endpoint. Result should be 200 with a list of sorted numbers

#Done:
  1. "Save" endpoint for saving numbers to txt file with 3 different sorting algorithms and execution time comparisons
  2. "Retrieve" endpoint for retrieving data from a saved file.

#Automated testing:
  1. Testing for services is done using XUnit. Most critical services are tested.
     
#Notes:
  1.  Input string should contain numbers only with whitespaces, otherwise an exception is thrown.
  2.  File is saved in a temp user folder. In order to change, need to reimplement IDirectoryService


