import { useEffect } from "react";
import axios from "axios";
import { backendUrl } from "utils/utils";

useEffect(() => {
  // Fazendo uma requisição GET
  axios
    .get(backendUrl)
    .then((response) => {})
    .catch((error) => {
      console.error(error);
    });
}, []);
