'use strict';

const loadButton = document.getElementById("load-button");
const videoTitleDiv = document.getElementById("video-title");
const errorMessageDiv = document.getElementById("error-message");

errorMessageDiv.style.display = "none";

loadButton.addEventListener("click", () => {
  // getVideoData(videoData => {
  //   videoTitleDiv.innerHTML = videoData[0].title;
  // }, error => {
  //   errorMessageDiv.style.display = "block";
  //   errorMessageDiv.innerHTML = error.toString();
  // });

  // the response has a json method which returns a promise of the repsonse body deserialized.
  fetch("https://www.scorebat.com/video-api/v1/",
    {
      method: "GET",
      headers: { "Accept": "application/json" }
    })
    .then(response => response.json())
    .then(videoData => {
      videoTitleDiv.innerHTML = videoData[0].title;
      console.log("this runs second");
    })
    .catch(error => {
      console.log(error);
      errorMessageDiv.style.display = "block";
      errorMessageDiv.innerHTML = error.toString();
    });

    console.log("this runs first");
});

function getVideoData(onSuccess, onError) {
  // clear previous error
  errorMessageDiv.style.display = "none";

  // the browser provides a XMLHttpRequest object/constructor
  // used for making HTTP requests.
  const xhr = new XMLHttpRequest();

  // XHR has a readyState property

  // configure what will happen as the request-response interaction occurs
  xhr.addEventListener("readystatechange", () => {
    console.log(`ready state: ${xhr.readyState}`);

    if (xhr.readyState === 4) {
      // if the response is fully downloaded
      if (xhr.status === 200) {
        // console.log(xhr.responseText);
        // built-in to the browser is JSON.parse and JSON.serialize
        // onSuccess(JSON.parse(xhr.responseText));
        onSuccess(xhr.response);
        // response will deserialize from JSON because of setting the type below.
      } else {
        onError(xhr.status);
      }
    }
  });

  xhr.open("GET", "https://www.scorebat.com/video-api/v1/");

  xhr.responseType = "json";
  xhr.setRequestHeader("Accept", "application/json");

  xhr.send();
}
