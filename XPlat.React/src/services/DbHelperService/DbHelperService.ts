import { Joke } from "../../types";
import { AllJokesResult, CreateDbResult, GetAllDbsResult } from "./types";

export const getAllDatabases = async () => {
  const response = await fetch("http://127.0.0.1:9696/api/get-all");
  const result = (await response.json()) as GetAllDbsResult;
  return result.message;
};

export const createDatabase = async () => {
  const response = await fetch("http://127.0.0.1:9696/api/create-db");
  const result = (await response.json()) as CreateDbResult;
  return result.message;
};

export const getAllJokes = async () => {
  const response = await fetch("http://127.0.0.1:9696/api/all-jokes");
  const result = (await response.json()) as AllJokesResult;
  return result.jokes;
};

export const selectDb = async (dbName: string) => {
  await fetch(`http://127.0.0.1:9696/api/select-db?dbName=${dbName.replace(".db", "")}`);
};

export const createJoke = async (joke: Joke) => {
  console.log({ joke });
  const response = await fetch("http://127.0.0.1:9696/api/add-joke", {
    method: "POST",
    body: JSON.stringify(joke),
  });
  const result = await response.json();
  return result as { message: string };
};
