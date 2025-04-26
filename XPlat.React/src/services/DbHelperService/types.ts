import { Joke } from "../../types";

export interface ApiResult {
  status: string;
}

export interface GetAllDbsResult extends ApiResult {
  message: string[];
}

export interface CreateDbResult extends ApiResult {
  message: string;
}

export interface AllJokesResult {
  jokes: Joke[];
}
