export function DisplayAlert(message)
{
  alert(message);
}

export function GetCurrentYear()
{
    var currentDate = new Date();
    return currentDate.getFullYear();
}


export function ToggleElement(element) {
  if (element == undefined) {
    return;
  }
  if (element.style.display == "none") {
    element.style.display = "block";
  } else {
    element.style.display = "none";
  }
}



