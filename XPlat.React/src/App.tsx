import DbListPage from "./pages/DbListPage";
import { useState } from "react";
import JokesListPage from "./pages/JokesListPage";
import { selectDb } from "./services/DbHelperService/DbHelperService";

function App() {
  const [selectedDb, setSelectedDb] = useState<string>();
  const pickDatabase = async (databaseName: string) => {
    await selectDb(databaseName);
    setSelectedDb(databaseName);
  };
  return (
    <>
      {!selectedDb && <DbListPage pickDatabase={pickDatabase} />}
      {selectedDb && <JokesListPage databaseName={selectedDb} />}
    </>
  );
}

export default App;
