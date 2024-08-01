async function fetchDataWithErrorHandling() {
    try {
        const response = await fetch("https://swapi.dev/api/people/1");
        if(!response.ok) throw new error("Network response is not ok");
        const data = await response.json();
        console.log(data);  
    } catch (error) {
        console.error("Fetch error:", error);
    }
}