import { useState, useEffect } from "react";
import { createDatabase, getAllDatabases } from "../services/DbHelperService/DbHelperService";
import { DatabaseIcon } from "lucide-react";
import DatabaseCard from "../components/DatabaseCard";

interface Props {
  pickDatabase: (name: string) => void;
}

export default function DbListPage(props: Props) {
  const [databases, setDatabases] = useState<string[]>([]);

  const fetchData = async () => {
    const data = await getAllDatabases();
    setDatabases(data);
  };

  useEffect(() => {
    fetchData();
  }, []);

  const addDatabase = async () => {
    await createDatabase();
    await fetchData();
  };

  return (
    <div className="min-h-screen bg-gray-50">
      <div className="max-w-7xl mx-auto px-4 py-8 sm:px-6 lg:px-8">
        <div className="flex justify-between items-center mb-8">
          <h1 className="text-3xl font-bold text-gray-900">My Databases</h1>
          <button
            onClick={addDatabase}
            className="bg-purple-500 text-white px-4 py-2 rounded-md hover:bg-purple-600 transition-colors flex items-center"
          >
            <DatabaseIcon className="w-4 h-4 mr-2" />
            Create Database
          </button>
        </div>

        {databases.length === 0 ? (
          <div className="text-center py-12">
            <DatabaseIcon className="mx-auto h-12 w-12 text-gray-400" />
            <h3 className="mt-2 text-sm font-medium text-gray-900">No databases</h3>
            <p className="mt-1 text-sm text-gray-500">Get started by creating a new database.</p>
          </div>
        ) : (
          <div className="grid gap-6 md:grid-cols-2 lg:grid-cols-3">
            {databases.map((database, index) => (
              <DatabaseCard key={database + index} name={database} onClick={props.pickDatabase} />
            ))}
          </div>
        )}
      </div>
    </div>
  );
}
