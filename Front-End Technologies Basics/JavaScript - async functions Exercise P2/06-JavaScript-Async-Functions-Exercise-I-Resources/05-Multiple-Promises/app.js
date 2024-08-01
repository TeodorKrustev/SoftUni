function multiplePromises() {
      const p1 = new Promise(function(resolve, reject){
            setTimeout(function(){
                  resolve("First promise is resolved");
            }, 1000);
      });
      const p2 = new Promise(function(resolve, reject){
            setTimeout(function(){
                  resolve("Second promise is resolved");
            }, 2000);
      });
      const p3 = new Promise(function(resolve, reject){
            setTimeout(function(){
                  reject("Third promise is rejected");
            }, 3000);
      });

      Promise.allSettled([p1, p2, p3]).then(results => {
            results.forEach(result => console.log(result.status, result.value || result.reason));
        });
};