import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faMapMarkerAlt, faSuitcase } from '@fortawesome/free-solid-svg-icons';

export default function InvitedLead() {
    return (
        <div className="bg-white shadow-md w-full mb-5">
            <div className="border-b border-gray-200">
                <div className="px-6 py-4">
                    <div className="flex items-center">
                        <div className="bg-primarylight text-white font-bold text-xl rounded-full w-12 h-12 flex items-center justify-center mr-4">
                            <span>UN</span>
                        </div>
                        <div>
                            <h2 className="font-semibold text-secondarydark">User Name</h2>
                            <p className="text-secondary text-sm">May 13, 2023</p>
                        </div>
                    </div>
                </div>
            </div>
            <div className="border-b border-gray-200">
                <div className="px-6 py-4">
                    <div className="flex text-secondary text-sm">
                        <div className="flex items-center mr-6">
                            <FontAwesomeIcon icon={faMapMarkerAlt} className="text-secondary mr-2" />
                            <span>1234 Address Street, City, State</span>
                        </div>
                        <div className="flex items-center mr-6">
                            <FontAwesomeIcon icon={faSuitcase} className="text-secondary mr-2" />
                            <span>Job Name</span>
                        </div>
                        <div className="flex items-center">
                            <span>Job ID:</span>
                            <span className="ml-2">12345</span>
                        </div>
                    </div>
                </div>
            </div>
            <div className="border-b border-gray-200">
                <div className="px-6 py-4">
                    <p className="text-secondary text-sm">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus lacinia odio vitae vestibulum vestibulum. Cras venenatis, ligula vel.</p>
                </div>
            </div>
            <div className="px-6 py-4">
                <div className="flex items-center">
                    <button className="bg-primary text-white font-semibold px-5 py-2 mr-2 border-solid border-b-2 border-primarydark">Accept</button>
                    <button className="bg-secondarylight text-secondarydark font-semibold px-5 py-2 border-solid border-b-2 border-secondary">Decline</button>
                    <div className="ml-8">
                        <span className="text-secondarydark font-semibold">$100</span>
                        <span className="text-secondary ml-2">Lead Invitation</span>
                    </div>
                </div>
            </div>
        </div>
    )
}
