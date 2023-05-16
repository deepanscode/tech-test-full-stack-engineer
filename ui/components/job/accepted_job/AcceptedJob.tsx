import {FontAwesomeIcon} from '@fortawesome/react-fontawesome';
import {faMapMarkerAlt, faSuitcase,faEnvelope,faPhone} from '@fortawesome/free-solid-svg-icons';
import format from "date-fns/format";
import { Job } from '@/models/job';

interface Props {
    job: Job
}

export default function AcceptedJob({job}: Props) {
    return (
        <div className="card-body">
            <div className="border-b border-gray-200">
                <div className="px-6 py-4">
                    <div className="flex items-center">
                        <div className="badge-user-icon">
                            <span>{job.contactName.charAt(0).toUpperCase() ?? "-"}</span>
                        </div>
                        <div>
                            <h2 className="font-semibold text-secondarydark">{job.contactName}</h2>
                            <p className="text-secondary text-sm">{format(new Date(job.createdAt), "MMMM dd yyyy") + ' @ ' + format(new Date(job.createdAt), "hh:mm aaa")}</p>
                        </div>
                    </div>
                </div>
            </div>
            <div className="border-b border-gray-200">
                <div className="px-6 py-4">
                    <div className="flex text-secondary text-sm">
                        <div className="flex items-center mr-6">
                            <FontAwesomeIcon icon={faMapMarkerAlt} className="text-secondary mr-2"/>
                            <span>{job.suburbName + " " + job.postcode}</span>
                        </div>
                        <div className="flex items-center mr-6">
                            <FontAwesomeIcon icon={faSuitcase} className="text-secondary mr-2"/>
                            <span>{job.categoryName}</span>
                        </div>
                        <div className="flex items-center mr-6">
                            <span>Job ID:</span>
                            <span className="ml-2">{job.id}</span>
                        </div>
                        <div className="flex items-center">
                            <span>${job.price.toFixed(2)}</span>
                            <span className="ml-2">Lead Invitation</span>
                        </div>
                    </div>
                </div>
            </div>
            <div className="border-b border-gray-200">
                <div className="px-6 py-4">
                    <div className="flex text-secondary text-sm">
                        <div className="flex items-center mr-6">
                            <FontAwesomeIcon icon={faPhone} className="text-secondary mr-2"/>
                            <span className="text-primarylight font-semibold">{job.contactPhone}</span>
                        </div>
                        <div className="flex items-center mr-6">
                            <FontAwesomeIcon icon={faEnvelope} className="text-secondary mr-2"/>
                            <span className="text-primarylight font-semibold">{job.contactEmail}</span>
                        </div>
                    </div>
                </div>
            </div>
            <div className="border-b border-gray-200">
                <div className="px-6 py-4">
                    <p className="text-secondary text-sm">{job.description}</p>
                </div>
            </div>
        </div>
    )
}
