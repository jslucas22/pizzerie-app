import axios from "axios";
import { useState } from "react";
import { backendUrl } from "utils/utils";

const [responseText, setResponseText] = useState("");

const handleDeleteRequest = () => {
  axios
    .delete(backendUrl + "/1") // Substitua '1' pelo ID correto
    .then((response) => {
      setResponseText("Exclusão bem-sucedida! Resposta: " + response.data);
    })
    .catch((error) => {
      console.error("Erro ao fazer DELETE:", error);
      setResponseText("Erro ao fazer a exclusão.");
    });
};
