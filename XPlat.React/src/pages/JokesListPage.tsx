import { Dice6, Plus } from "lucide-react";
import { useEffect, useState } from "react";
import { createJoke, getAllJokes } from "../services/DbHelperService/DbHelperService";
import { Joke } from "../types";

interface Props {
  databaseName: string;
}

export default function JokesListPage(props: Props) {
  const [jokes, setJokes] = useState<Joke[]>([]);

  const fetchJokes = async () => {
    const results = await getAllJokes();
    setJokes(results);
  };
  useEffect(() => {
    fetchJokes();
  }, []);

  const addJoke = async () => {
    await createJoke({ Setup: "What", Punchline: "Ahaha" });
    fetchJokes();
  };

  return (
    <div className="min-h-screen bg-gray-50 p-8">
      <div className="max-w-4xl mx-auto">
        <div className="flex justify-between items-center mb-8">
          <h1 className="text-3xl font-bold text-gray-900">{props.databaseName}</h1>
          <div className="flex gap-4 items-center">
            <button
              onClick={addJoke}
              className="bg-purple-500 text-white px-4 py-2 rounded-md hover:bg-purple-600 transition-colors flex items-center"
            >
              <Plus className="w-4 h-4 mr-2" />
              Add Joke
            </button>
            <div className="flex items-center gap-2">
              <input
                type="number"
                min="1"
                // value={randomCount}
                // onChange={(e) => setRandomCount(Number(e.target.value))}
                className="w-20 px-2 py-2 border rounded-md"
              />
              <button
                // onClick={addRandomJokes}
                className="bg-purple-500 text-white px-4 py-2 rounded-md hover:bg-purple-600 transition-colors flex items-center"
              >
                <Dice6 className="w-4 h-4 mr-2" />
                Add Random
              </button>
            </div>
          </div>
        </div>

        {jokes.length === 0 ? (
          <div className="text-center py-12">
            <Dice6 className="mx-auto h-12 w-12 text-gray-400" />
            <h3 className="mt-2 text-sm font-medium text-gray-900">No jokes yet</h3>
            <p className="mt-1 text-sm text-gray-500">Get started by adding a new joke.</p>
          </div>
        ) : (
          <div className="grid gap-6">
            {jokes.map((joke) => (
              <div key={joke.Id} className="bg-white rounded-lg shadow-md p-6">
                <h3 className="font-medium text-lg text-gray-800 mb-2">{joke.Setup}</h3>
                <p className="text-gray-600">{joke.Punchline}</p>
              </div>
            ))}
          </div>
        )}
      </div>
    </div>
  );
}
