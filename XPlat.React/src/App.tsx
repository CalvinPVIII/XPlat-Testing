import { useState, useEffect } from "react";

function App() {
  const [r, setR] = useState("No response");
  const [er, setEr] = useState("");

  useEffect(() => {
    const fetchInfo = async () => {
      try {
        const res = await fetch("http://127.0.0.1:9696/api/joke");
        if (!res.ok) {
          console.log("err");
          throw new Error(`Http Error, status: ${res.status}`);
        }
        const result = await res.json();
        setR(result);
      } catch (e: unknown) {
        if (e instanceof Error) {
          setEr(e.message);
        } else {
          setEr("An unknown error occurred");
        }
      }
    };
    fetchInfo();
  }, []);

  return (
    <>
      {!r && <p>Loading...</p>}
      {r && <h1>{r}</h1>}
      {er && <h1>{er}</h1>}
    </>
  );
}

export default App;
