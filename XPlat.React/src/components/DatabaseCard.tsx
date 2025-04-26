import { DatabaseIcon } from "lucide-react";

interface Props {
  name: string;
  onClick: (name: string) => void;
}

export default function DatabaseCard(props: Props) {
  const handleClick = () => {
    props.onClick(props.name);
  };

  return (
    <div className="bg-white rounded-lg shadow-md p-6 hover:shadow-lg transition-shadow duration-200 cursor-pointer" onClick={handleClick}>
      <div className="flex items-center space-x-4">
        <DatabaseIcon className="w-8 h-8 text-purple-500" />
        <div>
          <h3 className="font-medium text-gray-800">{props.name}</h3>
        </div>
      </div>
    </div>
  );
}
